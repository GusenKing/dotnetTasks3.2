import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:lesson5_flutter_calculator/calculator_operation_button.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.blue),
      ),
      debugShowCheckedModeBanner: false,
      home: const MyHomePage(title: 'Flutter Calculator'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});
  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  double firstNumber = 0;
  double secondNumber = 0;
  String result = "";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text(widget.title),
      ),
      body: Center(
        child: Container(
          padding: const EdgeInsets.all(32),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              TextField(
                decoration: InputDecoration(labelText: "Enter first number"),
                keyboardType: TextInputType.numberWithOptions(decimal: true),
                inputFormatters: [
                  FilteringTextInputFormatter.allow(RegExp('[0-9.,]')),
                ],
                onChanged:
                    (value) => setState(() {
                      firstNumber = double.parse(value);
                    }),
              ),
              TextField(
                decoration: InputDecoration(labelText: "Enter second number"),
                keyboardType: TextInputType.numberWithOptions(decimal: true),
                inputFormatters: [
                  FilteringTextInputFormatter.allow(RegExp('[0-9.,]')),
                ],
                onChanged:
                    (value) => setState(() {
                      secondNumber = double.parse(value);
                    }),
              ),
              Padding(padding: const EdgeInsets.only(top: 24)),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  calculatorOperationButton(
                    "+",
                    Theme.of(context).colorScheme.secondary,
                    () => setState(() {
                      var tempResult = firstNumber + secondNumber;
                      result = tempResult.toString();
                    }),
                  ),
                  calculatorOperationButton(
                    "-",
                    Theme.of(context).colorScheme.secondary,
                    () => setState(() {
                      var tempResult = firstNumber - secondNumber;
                      result = tempResult.toString();
                    }),
                  ),
                ],
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  calculatorOperationButton(
                    "x",
                    Theme.of(context).colorScheme.secondary,
                    () => setState(() {
                      var tempResult = firstNumber * secondNumber;
                      result = tempResult.toString();
                    }),
                  ),
                  calculatorOperationButton(
                    "/",
                    Theme.of(context).colorScheme.secondary,
                    () => setState(() {
                      if (secondNumber == 0) {
                        showDialog<String>(
                          context: context,
                          builder:
                              (BuildContext context) => AlertDialog(
                                title: const Text('Division by zero'),
                                content: const Text(
                                  'Division by zero is not allowed',
                                ),
                                actions: <Widget>[
                                  TextButton(
                                    onPressed:
                                        () => Navigator.pop(context, 'Cancel'),
                                    child: const Text('my bad'),
                                  ),
                                  TextButton(
                                    onPressed:
                                        () => Navigator.pop(context, 'OK'),
                                    child: const Text('stupid calculator'),
                                  ),
                                ],
                              ),
                        );
                        return;
                      }
                      var tempResult = firstNumber / secondNumber;
                      result = tempResult.toString();
                    }),
                  ),
                ],
              ),
              Padding(padding: const EdgeInsets.only(top: 24)),
              Text("= $result", style: TextStyle(fontSize: 24)),
            ],
          ),
        ),
      ),
    );
  }
}
