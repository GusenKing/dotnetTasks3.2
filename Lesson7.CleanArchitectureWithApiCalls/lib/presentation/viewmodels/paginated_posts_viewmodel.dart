import '../../domain/models/post.dart';
import '../../domain/usecases/get_paginated_posts_usecase.dart';

class PaginatedPostsViewModel {
  final GetPostsPaginatedUseCase useCase;
  int _page = 1;
  final int _perPage = 10;
  bool isLoading = false;
  bool hasMore = true;
  List<Post> posts = [];

  PaginatedPostsViewModel({required this.useCase});

  Future<void> fetchMore() async {
    if (isLoading || !hasMore) return;

    isLoading = true;
    final newPosts = await useCase.call(_page, _perPage);

    if (newPosts.length < _perPage) {
      hasMore = false;
    }

    posts.addAll(newPosts);
    _page++;
    isLoading = false;
  }
}
