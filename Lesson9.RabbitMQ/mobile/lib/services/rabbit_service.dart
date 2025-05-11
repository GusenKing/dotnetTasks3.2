import 'dart:async';
import 'package:dart_amqp/dart_amqp.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'auth_service.dart';

final rabbitServiceProvider = Provider((ref) => RabbitService(ref));

class RabbitService {
  final Ref _ref;
  RabbitService(this._ref);

  Client? _client;
  Queue? _logoutQueue;
  Queue? _msgQueue;
  StreamSubscription<AmqpMessage>? _sub;

  Future<void> connectAndSubscribe(String token) async {
    final settings = ConnectionSettings(
      host: '10.0.2.2',
      authProvider: PlainAuthenticator('guest', 'guest'),
    );
    _client = Client(settings: settings);
    final channel = await _client!.channel();

    final user = _ref.read(userProvider)!;
    final routingKey = 'user.${user['username']}';

    final logoutExchange = await channel.exchange(
      'logout_exchange',
      ExchangeType.TOPIC,
      durable: true,
    );
    _logoutQueue = await channel.queue('', durable: false, autoDelete: true);
    await _logoutQueue!.bind(logoutExchange, routingKey);

    final stream = await _logoutQueue!.consume(noAck: true);
    _sub = stream.listen((msg) {
      _ref.read(authServiceProvider).logout();
    });

    final messageExchange = await channel.exchange(
      'backend_exchange',
      ExchangeType.FANOUT,
      durable: true,
    );
    _msgQueue = await channel.queue('', durable: false, autoDelete: true);
    await _msgQueue!.bind(messageExchange, "");

    final msgStream = await _msgQueue!.consume(noAck: true);
    _sub = msgStream.listen((msg) {
      final text = msg.payloadAsJson["message"]["message"];
      print(text);
      _ref.read(messagesProvider.notifier).state = [
        ..._ref.read(messagesProvider),
        text,
      ];
    });
  }

  Future<void> disconnect() async {
    await _sub?.cancel();
    await _client?.close();
    _logoutQueue = null;
    _client = null;
  }
}

final messagesProvider = StateProvider<List<String>>((_) => []);
