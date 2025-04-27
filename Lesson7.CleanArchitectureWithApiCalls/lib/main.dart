import 'package:flutter/material.dart';
import 'package:dio/dio.dart';
import 'data/post_repository_implementation.dart';
import 'domain/usecases/get_post_usecase.dart';
import 'domain/usecases/get_paginated_posts_usecase.dart';
import 'presentation/pages/paginated_posts_page.dart';
import 'presentation/pages/single_post_page.dart';
import 'presentation/viewmodels/single_post_viewmodel.dart';
import 'presentation/viewmodels/paginated_posts_viewmodel.dart';

void main() {
  final dio = Dio();
  final repository = PostRepositoryImpl(dio: dio);

  runApp(MyApp(repository: repository));
}

class MyApp extends StatelessWidget {
  final PostRepositoryImpl repository;

  const MyApp({super.key, required this.repository});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter MVVM Clean',
      home: Scaffold(
        appBar: AppBar(title: Text('Flutter MVVM')),
        body: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              ElevatedButton(
                child: Text('Single Post'),
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder:
                          (_) => SinglePostPage(
                            viewModel: SinglePostViewModel(
                              useCase: GetPostUseCase(repository: repository),
                            ),
                          ),
                    ),
                  );
                },
              ),
              ElevatedButton(
                child: Text('Paginated Posts'),
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder:
                          (_) => PaginatedPostsPage(
                            viewModel: PaginatedPostsViewModel(
                              useCase: GetPostsPaginatedUseCase(
                                repository: repository,
                              ),
                            ),
                          ),
                    ),
                  );
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}
