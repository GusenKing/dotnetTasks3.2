import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../services/rabbit_service.dart';
import 'login_page.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final RabbitService _rabbit = RabbitService();
  String message = "";

  @override
  void initState() {
    super.initState();
    _start();
  }

  void _start() async {
    await _rabbit.connectAndSubscribe();
    _rabbit.messages.listen((msg) {
      setState(() {
        message = msg;
      });
    });
  }

  @override
  void dispose() {
    _rabbit.disconnect();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(title: Text('RabbitMQ Listener')),
        body: Center(
          child: Text(
            message,
            style: TextStyle(fontSize: 36),
            textAlign: TextAlign.center,
          ),
        ),
      ),
    );
  }
}
