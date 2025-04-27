import 'package:flutter/material.dart';
import 'core/di/service_locator.dart';
import 'presentation/pages/home_page.dart';

void main() {
  setupServiceLocator();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(title: 'Flutter MVVM Clean', home: const HomePage());
  }
}
