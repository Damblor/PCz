package com.example.kalkulator

import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class HistoryActivity : AppCompatActivity() {
    private lateinit var backButton: Button
    private lateinit var historyView: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_history)
        initialize()
        addButtonsListeners()
        showCalculationHistory()
    }

    private fun initialize()
    {
        backButton = findViewById(R.id.backButton)
        historyView = findViewById(R.id.historyView)
    }

    private fun addButtonsListeners()
    {
        backButton.setOnClickListener {
            finish()
        }
    }

    private fun showCalculationHistory()
    {
        for (i in 0 until MainActivity.history.size)
        {
            historyView.append(MainActivity.history[i] + "\n")
        }
    }
}
