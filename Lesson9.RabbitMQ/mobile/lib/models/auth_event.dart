class AuthEvent {
  final AuthEventType type;
  final String message;
  AuthEvent({required this.type, this.message = ''});
}

enum AuthEventType { success, failure, logout }
