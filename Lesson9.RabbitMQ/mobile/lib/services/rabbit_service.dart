import 'dart:async';
import 'package:dart_amqp/dart_amqp.dart';

class RabbitService {
  final String host;
  final int port;
  final String username;
  final String password;
  late Client _client;
  late Channel _channel;
  late Queue _queue;
  final StreamController<String> _controller = StreamController.broadcast();

  Stream<String> get messages => _controller.stream;

  RabbitService({
    this.host = '10.0.2.2',
    this.port = 5672,
    this.username = 'guest',
    this.password = 'guest',
  });

  Future<void> connectAndSubscribe({
    String exchangeName = 'Lesson9.Backend.Contracts:UpdateMessage',
    String queueName = '',
  }) async {
    var settings = ConnectionSettings(
      host: host,
      port: port,
      authProvider: PlainAuthenticator(username, password),
      virtualHost: '/',
    );

    _client = Client(settings: settings);
    _channel = await _client.channel();
    var exchange = await _channel.exchange(
      exchangeName,
      ExchangeType.FANOUT,
      durable: true,
    );

    _queue = await _channel.queue(queueName, durable: true, autoDelete: true);
    await _queue.bind(exchange, "");
    var queueConsumer = await _queue.consume(noAck: true);

    queueConsumer.listen((AmqpMessage msg) {
      _controller.add(msg.payloadAsJson["message"]["payload"]);
    });
  }

  Future<void> disconnect() async {
    await _controller.close();
    await _client.close();
  }
}
