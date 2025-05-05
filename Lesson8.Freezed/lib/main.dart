import 'package:lesson8_freezed/pages/home_page/my_home_page.dart';
import 'package:lesson8_freezed/utils/consts.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(primaryColor: primaryColor, useMaterial3: true),
      home: const MyHomePage(),
    );
  }
}
