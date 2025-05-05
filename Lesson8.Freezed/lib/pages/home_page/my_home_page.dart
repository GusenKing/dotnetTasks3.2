import 'package:lesson8_freezed/components/my_app_bar.dart';
import 'package:lesson8_freezed/pages/home_page/bloc/home_bloc.dart';
import 'package:lesson8_freezed/pages/home_page/bloc/home_event.dart';
import 'package:lesson8_freezed/pages/home_page/bloc/home_state.dart';
import 'package:lesson8_freezed/pages/home_page/widgets/list_with_loading_widget.dart';
import 'package:lesson8_freezed/components/my_app_button.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class MyHomePage extends StatelessWidget {
  const MyHomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => HomeBloc()..add(const HomeEvent.initialLoading()),
      child: const Scaffold(
        appBar: MyAppBar(appBarText: 'Задание с блоком и freezed'),
        body: _MyHomeView(),
      ),
    );
  }
}

class _MyHomeView extends StatelessWidget {
  const _MyHomeView();

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        return switch (state) {
          Loading _ => const Center(child: CircularProgressIndicator()),
          Error(:final message) => Center(child: Text(message)),
          Normal(
            :final data1,
            :final isLoading1,
            :final data2,
            :final isLoading2,
          ) =>
            Column(
              children: [
                ListWithLoadingWidget(isLoading: isLoading1, data: data1),
                MyAppButton(
                  buttonText: 'Click 1',
                  onClick: () {
                    context.read<HomeBloc>().add(const HomeEvent.loadData1());
                  },
                ),
                ListWithLoadingWidget(isLoading: isLoading2, data: data2),
                MyAppButton(
                  buttonText: 'Click 2',
                  onClick: () {
                    context.read<HomeBloc>().add(const HomeEvent.loadData2());
                  },
                ),
              ],
            ),
          _ => const Center(child: Text('Unknown state')),
        };
      },
    );
  }
}
