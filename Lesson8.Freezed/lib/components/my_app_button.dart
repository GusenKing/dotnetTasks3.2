import 'package:lesson8_freezed/utils/consts.dart';
import 'package:flutter/material.dart';

class MyAppButton extends StatelessWidget {
  final Function() onClick;
  final String buttonText;

  const MyAppButton({
    super.key,
    required this.onClick,
    required this.buttonText,
  });

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onClick,
      child: Container(
        padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 20),
        decoration: const BoxDecoration(
          borderRadius: BorderRadius.all(Radius.circular(6)),
          color: buttonColor,
        ),
        child: Text(buttonText),
      ),
    );
  }
}
