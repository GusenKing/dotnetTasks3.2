import 'package:flutter/material.dart';
import 'package:lesson7_clean_architecture/core/di/service_locator.dart';
import '../viewmodels/paginated_posts_viewmodel.dart';

class PaginatedPostsPage extends StatefulWidget {
  const PaginatedPostsPage({super.key});

  @override
  _PaginatedPostsPageState createState() => _PaginatedPostsPageState();
}

class _PaginatedPostsPageState extends State<PaginatedPostsPage> {
  late final PaginatedPostsViewModel viewModel;

  final ScrollController _controller = ScrollController();

  @override
  void initState() {
    super.initState();
    viewModel = serviceLocator<PaginatedPostsViewModel>();
    viewModel.fetchMore().then((_) {
      setState(() {});
    });
    _controller.addListener(() {
      if (_controller.position.pixels >=
          _controller.position.maxScrollExtent - 200) {
        viewModel.fetchMore().then((_) {
          setState(() {});
        });
      }
    });
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final posts = viewModel.posts;

    return Scaffold(
      appBar: AppBar(title: Text('Paginated Posts')),
      body: ListView.builder(
        controller: _controller,
        itemCount: posts.length + (viewModel.hasMore ? 1 : 0),
        itemBuilder: (context, index) {
          if (index < posts.length) {
            return ListTile(
              title: Text(
                posts[index].title,
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
              ),
              subtitle: Text(posts[index].body),
            );
          } else {
            return Center(
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: CircularProgressIndicator(),
              ),
            );
          }
        },
      ),
    );
  }
}
