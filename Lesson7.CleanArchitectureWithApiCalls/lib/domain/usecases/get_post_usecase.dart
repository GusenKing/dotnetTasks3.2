import '../models/post.dart';
import '../repositories/post_repository.dart';

class GetPostUseCase {
  final PostRepository repository;

  GetPostUseCase({required this.repository});

  Future<Post> call() => repository.getPost();
}
