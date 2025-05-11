import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import '../services/auth_service.dart';
import '../services/rabbit_service.dart';

class HomePage extends ConsumerWidget {
  @override
  Widget build(BuildContext ctx, WidgetRef ref) {
    final messages = ref.watch(messagesProvider);
    final user = ref.watch(userProvider)!;
    return Scaffold(
      appBar: AppBar(
        title: Text('Welcome, ${user['username']}'),
        actions: [
          IconButton(
            icon: Icon(Icons.logout),
            onPressed: () => ref.read(authServiceProvider).logout(),
          ),
        ],
      ),
      body: ListView.builder(
        itemCount: messages.length,
        itemBuilder: (_, i) => ListTile(title: Text(messages[i])),
      ),
    );
  }
}
