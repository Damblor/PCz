package com.example.labirynt

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView

class EndGameActivity : AppCompatActivity() {
    private lateinit var restartButton: Button
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_end_game)
        restartButton = findViewById(R.id.restartButton)
        findViewById<TextView>(R.id.scoreView).text = GameActivity.score.toString()
        restartButton.setOnClickListener {
            startActivity(Intent(this, MainActivity::class.java))
        }
    }
}