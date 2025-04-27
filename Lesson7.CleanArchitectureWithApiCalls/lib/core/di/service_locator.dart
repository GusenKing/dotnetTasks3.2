import 'package:get_it/get_it.dart';
import 'package:dio/dio.dart';

import '../../data/post_repository_implementation.dart';
import '../../domain/usecases/get_post_usecase.dart';
import '../../domain/usecases/get_paginated_posts_usecase.dart';
import '../../presentation/viewmodels/single_post_viewmodel.dart';
import '../../presentation/viewmodels/paginated_posts_viewmodel.dart';
import '../../domain/repositories/post_repository.dart';

final GetIt serviceLocator = GetIt.instance;

void setupServiceLocator() {
  // Core
  serviceLocator.registerLazySingleton<Dio>(() => Dio());

  // Repository
  serviceLocator.registerLazySingleton<PostRepository>(
    () => PostRepositoryImplementation(dio: serviceLocator()),
  );

  // UseCases
  serviceLocator.registerLazySingleton<GetPostUseCase>(
    () => GetPostUseCase(repository: serviceLocator()),
  );
  serviceLocator.registerLazySingleton<GetPostsPaginatedUseCase>(
    () => GetPostsPaginatedUseCase(repository: serviceLocator()),
  );

  // ViewModels
  serviceLocator.registerFactory<SinglePostViewModel>(
    () => SinglePostViewModel(useCase: serviceLocator()),
  );
  serviceLocator.registerFactory<PaginatedPostsViewModel>(
    () => PaginatedPostsViewModel(useCase: serviceLocator()),
  );
}
