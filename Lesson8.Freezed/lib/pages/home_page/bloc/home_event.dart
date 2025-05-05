import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:flutter/foundation.dart';

part 'home_event.freezed.dart';

@freezed
abstract class HomeEvent with _$HomeEvent {
  const factory HomeEvent.initialLoading() = InitialLoading;
  const factory HomeEvent.loadData1() = LoadData1;
  const factory HomeEvent.loadData2() = LoadData2;
}
