import 'package:flutter/material.dart';
import '../viewmodels/paginated_posts_viewmodel.dart';

class PaginatedPostsPage extends StatefulWidget {
  final PaginatedPostsViewModel viewModel;

  const PaginatedPostsPage({super.key, required this.viewModel});

  @override
  _PaginatedPostsPageState createState() => _PaginatedPostsPageState();
}

class _PaginatedPostsPageState extends State<PaginatedPostsPage> {
  final ScrollController _controller = ScrollController();

  @override
  void initState() {
    super.initState();
    widget.viewModel.fetchMore();
    _controller.addListener(() {
      if (_controller.position.pixels >=
          _controller.position.maxScrollExtent - 200) {
        widget.viewModel.fetchMore().then((_) {
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
    final posts = widget.viewModel.posts;

    return Scaffold(
      appBar: AppBar(title: Text('Paginated Posts')),
      body: ListView.builder(
        controller: _controller,
        itemCount: posts.length + (widget.viewModel.hasMore ? 1 : 0),
        itemBuilder: (context, index) {
          if (index < posts.length) {
            return ListTile(
              title: Text(posts[index].title),
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
