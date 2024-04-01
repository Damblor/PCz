package com.example.labirynt

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.TextView

class MainActivity : AppCompatActivity() {
    private lateinit var xDimensionText: TextView
    private lateinit var yDimensionText: TextView

    companion object {
        var xDimension: Int = 4
        var yDimension: Int = 4
    }
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        xDimensionText = findViewById(R.id.xSize)
        yDimensionText = findViewById(R.id.ySize)
    }

    fun startGame(view: View) {
        if(xDimensionText.text.toString().toIntOrNull() != null && yDimensionText.text.toString().toIntOrNull() != null) {
            if(xDimensionText.text.toString().toInt() > 3 && yDimensionText.text.toString().toInt() > 3) {
                xDimension = xDimensionText.text.toString().toInt()
                yDimension = yDimensionText.text.toString().toInt()
                startActivity(Intent(this, GameActivity::class.java))
            }
        }
    }
}
