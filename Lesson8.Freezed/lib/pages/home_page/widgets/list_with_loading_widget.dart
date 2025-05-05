import 'package:flutter/material.dart';
import 'package:lesson8_freezed/pages/home_page/models/home_data_dto.dart';

class ListWithLoadingWidget extends StatelessWidget {
  final bool isLoading;
  final List<HomeDataDto> data;

  const ListWithLoadingWidget({
    super.key,
    required this.isLoading,
    required this.data,
  });

  @override
  Widget build(BuildContext context) {
    return isLoading
        ? const CircularProgressIndicator()
        : SizedBox(
          width: double.maxFinite,
          height: 60,
          child: ListView.builder(
            shrinkWrap: true,
            itemCount: data.length,
            itemBuilder:
                (context, index) => Container(
                  decoration: BoxDecoration(
                    border: Border.all(color: Colors.blueAccent),
                    borderRadius: const BorderRadius.all(Radius.circular(6)),
                  ),
                  margin: const EdgeInsets.only(right: 10, left: 10),
                  padding: const EdgeInsets.all(5),
                  child: Center(
                    child: Column(
                      children: [
                        Text(data[index].id.toString()),
                        Text(data[index].name),
                      ],
                    ),
                  ),
                ),
            scrollDirection: Axis.horizontal,
          ),
        );
  }
}
