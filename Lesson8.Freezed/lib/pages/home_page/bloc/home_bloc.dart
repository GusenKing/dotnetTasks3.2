import 'dart:async';

import 'package:lesson8_freezed/pages/home_page/bloc/home_event.dart';
import 'package:lesson8_freezed/pages/home_page/bloc/home_state.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:lesson8_freezed/pages/home_page/models/home_data_dto.dart';

class HomeBloc extends Bloc<HomeEvent, HomeState> {
  HomeBloc() : super(const HomeState.loading()) {
    on<InitialLoading>(startInitialLoading);
    on<LoadData1>(_startLoadFirstListData);
    on<LoadData2>(_startLoadSecondListData);
  }

  FutureOr<void> _startLoadFirstListData(
    LoadData1 event,
    Emitter<HomeState> emit,
  ) async {
    final currentState = state;
    if (currentState is Normal) {
      emit(currentState.copyWith(isLoading1: true));
      await Future.delayed(const Duration(seconds: 1));
      final data = List.generate(
        3,
        (i) => HomeDataDto(id: i, name: 'Item A$i'),
      );
      emit(currentState.copyWith(data1: data, isLoading1: false));
    }
  }

  FutureOr<void> _startLoadSecondListData(
    LoadData2 event,
    Emitter<HomeState> emit,
  ) async {
    final currentState = state;
    if (currentState is Normal) {
      emit(currentState.copyWith(isLoading2: true));
      await Future.delayed(const Duration(seconds: 2));
      final data = List.generate(
        3,
        (i) => HomeDataDto(id: i, name: 'Item B$i'),
      );
      emit(currentState.copyWith(data2: data, isLoading2: false));
    }
  }

  Future<FutureOr<void>> startInitialLoading(
    InitialLoading event,
    Emitter<HomeState> emit,
  ) async {
    await Future.delayed(const Duration(seconds: 2));
    emit(
      HomeState.normal(
        data1: [
          HomeDataDto(id: 1, name: 'something'),
          HomeDataDto(id: 2, name: 'asd'),
          HomeDataDto(id: 3, name: 'qwe'),
          HomeDataDto(id: 4, name: 'zxc'),
        ],
        isLoading1: false,
        data2: [HomeDataDto(id: 1, name: 'something 123')],
        isLoading2: false,
      ),
    );
  }
}
