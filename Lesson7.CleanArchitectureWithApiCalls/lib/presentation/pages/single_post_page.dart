import 'package:flutter/material.dart';
import '../viewmodels/single_post_viewmodel.dart';
import '../../domain/models/post.dart';

class SinglePostPage extends StatefulWidget {
  final SinglePostViewModel viewModel;

  const SinglePostPage({super.key, required this.viewModel});

  @override
  _SinglePostPageState createState() => _SinglePostPageState();
}

class _SinglePostPageState extends State<SinglePostPage> {
  Post? post;
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    widget.viewModel.fetchPost().then((value) {
      setState(() {
        post = value;
        isLoading = false;
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Single Post')),
      body:
          isLoading
              ? Center(child: CircularProgressIndicator())
              : Padding(
                padding: EdgeInsets.all(16),
                child: Text(post?.body ?? 'No data'),
              ),
    );
  }
}
