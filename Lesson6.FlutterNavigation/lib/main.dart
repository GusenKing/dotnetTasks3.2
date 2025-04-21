import 'package:flutter/material.dart';
import 'package:lesson6_flutter_navigation/second_page.dart';
import 'package:lesson6_flutter_navigation/pseudo_cache.dart';
import 'package:lesson6_flutter_navigation/details_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Navigation',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.blue),
      ),
      home: const MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});
  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage>
    with SingleTickerProviderStateMixin {
  late TabController _tabController;

  @override
  void initState() {
    super.initState();
    _tabController = TabController(length: 2, vsync: this);
  }

  void _openDrawerPage(Widget page) {
    Navigator.of(context).push(MaterialPageRoute(builder: (_) => page));
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text("Main Page"),
      ),
      drawer: Drawer(
        child: ListView(
          children: [
            DrawerHeader(child: Text("Menu", style: TextStyle(fontSize: 24))),
            ListTile(
              title: Text("Main Page"),
              onTap: () => Navigator.pop(context),
            ),
            ListTile(
              title: Text("Second Page"),
              onTap: () => _openDrawerPage(SecondPage()),
            ),
          ],
        ),
      ),
      body: Column(
        children: [
          TabBar(
            controller: _tabController,
            tabs: [Tab(text: "List"), Tab(text: "Menu")],
          ),
          Expanded(
            child: TabBarView(
              controller: _tabController,
              children: [
                ListView.builder(
                  itemCount: cachedItems.length,
                  itemBuilder: (context, index) {
                    final item = cachedItems[index];
                    return ListTile(
                      title: Text(item.title),
                      trailing: ElevatedButton(
                        child: Text("Go to"),
                        onPressed: () {
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (_) => DetailPage(item: item),
                            ),
                          );
                        },
                      ),
                    );
                  },
                ),
                Center(
                  child: ElevatedButton(
                    child: Text("Show Menu in Modal Bottom Sheet"),
                    onPressed: () {
                      showModalBottomSheet(
                        context: context,
                        builder:
                            (context) => Center(
                              child: Text(
                                "Fishy fish",
                                style: TextStyle(fontSize: 18),
                              ),
                            ),
                      );
                    },
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
