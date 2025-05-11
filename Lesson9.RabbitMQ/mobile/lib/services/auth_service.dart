import 'dart:convert';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:http/http.dart' as http;
import 'package:mobile/services/rabbit_service.dart';
import 'package:shared_preferences/shared_preferences.dart';

final authServiceProvider = Provider((ref) => AuthService(ref));

class AuthService {
  final Ref _ref;
  AuthService(this._ref);

  static const _baseUrl = 'http://10.0.2.2:5000/api';
  static const _tokenKey = 'auth_token';

  Future<bool> tryAutoLogin() async {
    final prefs = await SharedPreferences.getInstance();
    final token = prefs.getString(_tokenKey);
    if (token == null) return false;

    // Проверяем валидность токена у бэка
    final resp = await http.get(
      Uri.parse('$_baseUrl/auth/check'),
      headers: {'Authorization': 'Bearer $token'},
    );
    if (resp.statusCode == 200) {
      // валидно
      _ref.read(userProvider.notifier).state = jsonDecode(resp.body);
      _ref.read(rabbitServiceProvider).connectAndSubscribe(token);
      return true;
    } else {
      await logout();
      return false;
    }
  }

  Future<bool> login(String username, String password) async {
    final resp = await http.post(
      Uri.parse('$_baseUrl/auth/login'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({'username': username, 'password': password}),
    );
    if (resp.statusCode == 200) {
      final data = jsonDecode(resp.body);
      final token = data['token'] as String;
      final prefs = await SharedPreferences.getInstance();
      await prefs.setString(_tokenKey, token);
      _ref.read(userProvider.notifier).state = data['user'];
      _ref.read(rabbitServiceProvider).connectAndSubscribe(token);
      return true;
    }
    return false;
  }

  Future<void> logout() async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.remove(_tokenKey);
    _ref.read(userProvider.notifier).state = null;
    await _ref.read(rabbitServiceProvider).disconnect();
  }
}

final userProvider = StateProvider<Map<String, dynamic>?>((_) => null);
