import '../models/post.dart';

abstract class PostRepository {
  Future<Post> getPost();
  Future<List<Post>> getPostsPaginated(int page, int perPage);
}
