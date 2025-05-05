import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:flutter/foundation.dart';

part 'home_data_dto.freezed.dart';
part 'home_data_dto.g.dart';

@freezed
abstract class HomeDataDto with _$HomeDataDto {
  const factory HomeDataDto({required int id, required String name}) =
      _HomeDataDto;

  factory HomeDataDto.fromJson(Map<String, dynamic> json) =>
      _$HomeDataDtoFromJson(json);
}
