import 'package:dio/dio.dart';
import '../../domain/models/post.dart';
import '../../domain/repositories/post_repository.dart';

class PostRepositoryImpl implements PostRepository {
  final Dio dio;

  PostRepositoryImpl({required this.dio});

  @override
  Future<Post> getPost() async {
    final response = await dio.get(
      'https://jsonplaceholder.typicode.com/posts/1',
    );
    return Post.fromJson(response.data);
  }

  @override
  Future<List<Post>> getPostsPaginated(int page, int perPage) async {
    final response = await dio.get(
      'https://jsonplaceholder.typicode.com/posts',
      queryParameters: {'_page': page, '_limit': perPage},
    );

    return (response.data as List).map((json) => Post.fromJson(json)).toList();
  }
}
