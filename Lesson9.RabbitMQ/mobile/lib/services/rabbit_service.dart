import 'package:dart_amqp/dart_amqp.dart';
import 'package:shared_preferences/shared_preferences.dart';

class RabbitService {
  late Client client;
  late Channel channel;
  late String sessionKey = 'session_id';
  late String usernameKey = 'username';

  Future<void> connect() async {
    client = Client(settings: ConnectionSettings(host: 'localhost'));
    channel = await client.channel();
  }

  Future<Guid?> loadSession() async {
    final prefs = await SharedPreferences.getInstance();
    final sid = prefs.getString(sessionKey);
    if (sid != null) return Guid.parse(sid);
    return null;
  }

  Future<bool> validateSession(Guid sessionId) async {
    final rpcClient = channel.rpc();
    final resp = await rpcClient
        .wrap('validate-service')
        .request(ValidateRequest(sessionId));
    return resp.valid;
  }

  Future<Guid?> login(String username) async {
    final rpcClient = channel.rpc();
    final req = LoginRequest(username, Guid.newGuid());
    final resp = await rpcClient.wrap('login-service').request(req);
    if (resp.success) {
      final prefs = await SharedPreferences.getInstance();
      prefs.setString(usernameKey, username);
      prefs.setString(sessionKey, resp.sessionId.toString());
      _subscribeKickOut(resp.sessionId);
      _subscribeUpdates(resp.sessionId);
      return resp.sessionId;
    }
    return null;
  }

  void _subscribeKickOut(Guid sessionId) async {
    final queue = await channel.queue('kickout.\${sessionId}', durable: false);
    queue.consume((msg) {
      // обрабатывать выход: удалить prefs и перейти на экран логина
    });
  }

  void _subscribeUpdates(Guid sessionId) async {
    // фан-аут топик 'updates'
    final exchange = await channel.exchange('updates', ExchangeType.FANOUT);
    final q = await channel.queue('', exclusive: true);
    await q.bind(exchange, '');
    q.consume((msg) {
      print('Получено сообщение: \${msg.payload}');
      // обновить UI
    });
  }
}
