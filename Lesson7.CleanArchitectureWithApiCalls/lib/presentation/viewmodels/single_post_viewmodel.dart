import '../../domain/models/post.dart';
import '../../domain/usecases/get_post_usecase.dart';

class SinglePostViewModel {
  final GetPostUseCase useCase;

  SinglePostViewModel({required this.useCase});

  Future<Post> fetchPost() => useCase.call();
}
