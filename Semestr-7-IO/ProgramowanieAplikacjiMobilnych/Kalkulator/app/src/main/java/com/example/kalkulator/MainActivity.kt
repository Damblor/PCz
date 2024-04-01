package com.example.kalkulator

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import java.util.Stack

class MainActivity : AppCompatActivity() {
    private lateinit var calculationView: TextView
    private lateinit var historyButton: Button
    private lateinit var clearButton: Button
    private lateinit var binButton: Button
    private lateinit var decButton: Button
    private lateinit var hexButton: Button
    private lateinit var octButton: Button
    private lateinit var powerButton: Button
    private lateinit var addButton: Button
    private lateinit var subButton: Button
    private lateinit var mulButton: Button
    private lateinit var divButton: Button
    private lateinit var dotButton: Button
    private lateinit var equalButton: Button
    private lateinit var zeroButton: Button
    private lateinit var oneButton: Button
    private lateinit var twoButton: Button
    private lateinit var threeButton: Button
    private lateinit var fourButton: Button
    private lateinit var fiveButton: Button
    private lateinit var sixButton: Button
    private lateinit var sevenButton: Button
    private lateinit var eightButton: Button
    private lateinit var nineButton: Button
    private lateinit var calculateString: String

    companion object {
        var history: MutableList<String> = mutableListOf()
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        initialize()
        addButtonsListeners()
    }

    private fun initialize() {
        calculationView = findViewById(R.id.calculationView)
        calculateString = ""
        historyButton = findViewById(R.id.historyButton)
        clearButton = findViewById(R.id.clearButton)
        binButton = findViewById(R.id.binButton)
        decButton = findViewById(R.id.decButton)
        hexButton = findViewById(R.id.hexButton)
        octButton = findViewById(R.id.octButton)
        powerButton = findViewById(R.id.powerButton)
        addButton = findViewById(R.id.addButton)
        subButton = findViewById(R.id.subButton)
        mulButton = findViewById(R.id.mulButton)
        divButton = findViewById(R.id.divButton)
        dotButton = findViewById(R.id.dotButton)
        equalButton = findViewById(R.id.equalButton)
        zeroButton = findViewById(R.id.zeroButton)
        oneButton = findViewById(R.id.oneButton)
        twoButton = findViewById(R.id.twoButton)
        threeButton = findViewById(R.id.threeButton)
        fourButton = findViewById(R.id.fourButton)
        fiveButton = findViewById(R.id.fiveButton)
        sixButton = findViewById(R.id.sixButton)
        sevenButton = findViewById(R.id.sevenButton)
        eightButton = findViewById(R.id.eightButton)
        nineButton = findViewById(R.id.nineButton)
    }

    private fun addButtonsListeners() {
        historyButton.setOnClickListener {
            val intent = Intent(this, HistoryActivity::class.java)
            startActivity(intent)
        }
        clearButton.setOnClickListener {
            clearCalculate()
        }
        powerButton.setOnClickListener {
            addStringToCalculate(" ^ ")
        }
        addButton.setOnClickListener {
            addStringToCalculate(" + ")
        }
        subButton.setOnClickListener {
            addStringToCalculate(" - ")
        }
        mulButton.setOnClickListener {
            addStringToCalculate(" * ")
        }
        divButton.setOnClickListener {
            addStringToCalculate(" / ")
        }
        dotButton.setOnClickListener {
            addStringToCalculate(".")
        }
        equalButton.setOnClickListener {
            calculate()
        }
        binButton.setOnClickListener {
            convert(NumberSystem.BINARY)
        }
        decButton.setOnClickListener {
            convert(NumberSystem.DECIMAL)
        }
        hexButton.setOnClickListener {
            convert(NumberSystem.HEXADECIMAL)
        }
        octButton.setOnClickListener {
            convert(NumberSystem.OCTAL)
        }
        zeroButton.setOnClickListener {
            addStringToCalculate("0")
        }
        oneButton.setOnClickListener {
            addStringToCalculate("1")
        }
        twoButton.setOnClickListener {
            addStringToCalculate("2")
        }
        threeButton.setOnClickListener {
            addStringToCalculate("3")
        }
        fourButton.setOnClickListener {
            addStringToCalculate("4")
        }
        fiveButton.setOnClickListener {
            addStringToCalculate("5")
        }
        sixButton.setOnClickListener {
            addStringToCalculate("6")
        }
        sevenButton.setOnClickListener {
            addStringToCalculate("7")
        }
        eightButton.setOnClickListener {
            addStringToCalculate("8")
        }
        nineButton.setOnClickListener {
            addStringToCalculate("9")
        }
    }

    private fun addStringToCalculate(string: String) {
        if (calculateString == "" && (string == " ^ " || string == " + " || string == " - " || string == " * " || string == " / ")) return
        else if (calculateString =="" && string == ".")
            calculateString = "0."
        else
            calculateString += string
        calculationView.text = calculateString
    }

    private fun clearCalculate() {
        calculateString = ""
        calculationView.text = calculateString
    }

    private fun convert(numberSystem: NumberSystem) {
        if (calculateString == "" || calculateString.toDoubleOrNull() == null) return
        val number = calculateString.toDouble().toLong()
        when (numberSystem) {
            NumberSystem.BINARY -> {
                calculationView.text = number.toString(2)
            }
            NumberSystem.DECIMAL -> {
                calculationView.text = number.toString(10)
            }
            NumberSystem.HEXADECIMAL -> {
                calculationView.text = number.toString(16)
            }
            NumberSystem.OCTAL -> {
                calculationView.text = number.toString(8)
            }
        }
    }

    private fun toRPN(input: String): List<String> {
        val output = mutableListOf<String>()
        val stack = Stack<Char>()
        val precedence = mapOf('+' to 1, '-' to 1, '*' to 2, '/' to 2, '^' to 3)
        for (token in input.split(" ")) {
            when {
                token.toDoubleOrNull() != null -> output.add(token)
                token.length == 1 && token[0] in precedence.keys -> {
                    while (stack.isNotEmpty() && (precedence[stack.peek()]
                            ?: 0) >= (precedence[token[0]] ?: 0)
                    ) {
                        output.add(stack.pop().toString())
                    }
                    stack.push(token[0])
                }
            }
        }
        while (stack.isNotEmpty()) {
            output.add(stack.pop().toString())
        }
        return output
    }

    private fun calculateRPN(rpn: List<String>): Double {
        val stack = Stack<Double>()
        for (token in rpn) {
            when {
                token.toDoubleOrNull() != null -> stack.push(token.toDouble())
                token.length == 1 && token[0] in "+-*/^" -> {
                    val operand2 = stack.pop()
                    val operand1 = stack.pop()
                    val result = when (token[0]) {
                        '+' -> operand1 + operand2
                        '-' -> operand1 - operand2
                        '*' -> operand1 * operand2
                        '/' -> operand1 / operand2
                        '^' -> Math.pow(operand1, operand2)
                        else -> throw IllegalArgumentException("Invalid operator")
                    }
                    stack.push(result)
                }
            }
        }
        if (stack.size != 1) {
            throw IllegalArgumentException("Invalid RPN expression")
        }
        return stack.pop()
    }

    private fun calculate() {
        if (calculateString == "") return
        val calculations = toRPN(calculateString)
        val result = if(calculateRPN(calculations) % 1 == 0.0) {
            calculateRPN(calculations).toInt()
        } else {
            calculateRPN(calculations).toInt()
        }
        history.add("$calculateString = $result")
        calculateString = result.toString()
        calculationView.text = calculateString
    }
}

enum class NumberSystem {
    BINARY, DECIMAL, HEXADECIMAL, OCTAL
}
