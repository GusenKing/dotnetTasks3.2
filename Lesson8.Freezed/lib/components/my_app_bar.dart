import 'package:lesson8_freezed/utils/consts.dart';
import 'package:flutter/material.dart';

class MyAppBar extends StatelessWidget implements PreferredSizeWidget {
  final String appBarText;

  const MyAppBar({super.key, required this.appBarText});

  @override
  Widget build(BuildContext context) {
    return AppBar(backgroundColor: primaryColor, title: Text(appBarText));
  }

  @override
  Size get preferredSize => const Size.fromHeight(toolbarHeight);
}
