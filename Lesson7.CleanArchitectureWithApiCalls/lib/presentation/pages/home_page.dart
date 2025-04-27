import 'package:flutter/material.dart';
import 'single_post_page.dart';
import 'paginated_posts_page.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Flutter MVVM')),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            ElevatedButton(
              child: const Text('Single Post'),
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (_) => const SinglePostPage()),
                );
              },
            ),
            ElevatedButton(
              child: const Text('Paginated Posts'),
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (_) => const PaginatedPostsPage()),
                );
              },
            ),
          ],
        ),
      ),
    );
  }
}
