import 'package:flutter/material.dart';
import 'package:lesson7_clean_architecture/core/di/service_locator.dart';
import '../viewmodels/single_post_viewmodel.dart';
import '../../domain/models/post.dart';

class SinglePostPage extends StatefulWidget {
  const SinglePostPage({super.key});

  @override
  _SinglePostPageState createState() => _SinglePostPageState();
}

class _SinglePostPageState extends State<SinglePostPage> {
  late final SinglePostViewModel viewModel;

  Post? post;
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    viewModel = serviceLocator<SinglePostViewModel>();
    viewModel.fetchPost().then((value) {
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
                child: Column(
                  children: [
                    Text(
                      post?.title ?? 'No data',
                      style: TextStyle(
                        fontSize: 18,
                        fontWeight: FontWeight.bold,
                      ),
                      textAlign: TextAlign.center,
                    ),
                    Text(post?.body ?? 'No data', textAlign: TextAlign.left),
                  ],
                ),
              ),
    );
  }
}
