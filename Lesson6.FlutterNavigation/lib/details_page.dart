import 'package:flutter/material.dart';
import 'pseudo_cache.dart';

class DetailPage extends StatelessWidget {
  final Item item;

  const DetailPage({super.key, required this.item});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text(item.title)),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Text(item.content, style: TextStyle(fontSize: 18)),
      ),
    );
  }
}
