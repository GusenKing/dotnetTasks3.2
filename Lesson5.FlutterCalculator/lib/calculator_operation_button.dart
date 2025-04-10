import 'package:flutter/material.dart';

Widget calculatorOperationButton(
  String buttonText,
  Color buttonColor,
  void Function()? buttonPressed,
) {
  return Container(
    width: 75,
    height: 75,
    padding: const EdgeInsets.all(4),
    child: ElevatedButton(
      onPressed: buttonPressed,
      style: ElevatedButton.styleFrom(
        shape: const RoundedRectangleBorder(
          borderRadius: BorderRadius.all(Radius.circular(20)),
        ),
        backgroundColor: buttonColor,
      ),
      child: Text(
        buttonText,
        style: const TextStyle(fontSize: 27, color: Colors.white),
      ),
    ),
  );
}
