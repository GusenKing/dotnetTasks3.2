import 'package:flutter/material.dart';

class LoginPage extends StatefulWidget {
  final void Function(String) onLogin;
  const LoginPage({super.key, required this.onLogin});
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final TextEditingController _ctrl = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.all(16),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          TextField(
            controller: _ctrl,
            decoration: InputDecoration(labelText: 'Username'),
          ),
          SizedBox(height: 16),
          ElevatedButton(
            onPressed: () => widget.onLogin(_ctrl.text.trim()),
            child: Text('Login'),
          ),
        ],
      ),
    );
  }
}
