import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:flutter/foundation.dart';
import '../models/home_data_dto.dart';

part 'home_state.freezed.dart';

@freezed
abstract class HomeState with _$HomeState {
  const factory HomeState.loading() = Loading;
  const factory HomeState.error(String message) = Error;

  const factory HomeState.normal({
    required List<HomeDataDto> data1,
    required bool isLoading1,
    required List<HomeDataDto> data2,
    required bool isLoading2,
  }) = Normal;
}
