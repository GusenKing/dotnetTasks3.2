import '../models/post.dart';
import '../repositories/post_repository.dart';

class GetPostsPaginatedUseCase {
  final PostRepository repository;

  GetPostsPaginatedUseCase({required this.repository});

  Future<List<Post>> call(int page, int perPage) =>
      repository.getPostsPaginated(page, perPage);
}
