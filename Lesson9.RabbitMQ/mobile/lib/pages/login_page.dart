import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

import '../services/auth_service.dart';

class LoginPage extends ConsumerStatefulWidget {
  const LoginPage({super.key});
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends ConsumerState<LoginPage> {
  final _userCtl = TextEditingController();
  final _passCtl = TextEditingController();
  bool _loading = false;
  String? _error;

  void _doLogin() async {
    setState(() {
      _loading = true;
      _error = null;
    });
    final ok = await ref
        .read(authServiceProvider)
        .login(_userCtl.text.trim(), _passCtl.text);
    setState(() => _loading = false);
    if (!ok) {
      setState(() => _error = 'Неверные логин/пароль');
    }
  }

  @override
  Widget build(BuildContext ctx) {
    return Scaffold(
      appBar: AppBar(title: Text('Login')),
      body: Padding(
        padding: EdgeInsets.all(16),
        child: Column(
          children: [
            TextField(
              controller: _userCtl,
              decoration: InputDecoration(labelText: 'Username'),
            ),
            TextField(
              controller: _passCtl,
              decoration: InputDecoration(labelText: 'Password'),
              obscureText: true,
            ),
            if (_error != null) ...[
              SizedBox(height: 8),
              Text(_error!, style: TextStyle(color: Colors.red)),
            ],
            SizedBox(height: 16),
            ElevatedButton(
              onPressed: _loading ? null : _doLogin,
              child: _loading ? CircularProgressIndicator() : Text('Log in'),
            ),
          ],
        ),
      ),
    );
  }
}
