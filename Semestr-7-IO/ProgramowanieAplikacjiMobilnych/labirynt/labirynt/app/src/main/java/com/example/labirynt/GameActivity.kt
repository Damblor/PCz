package com.example.labirynt

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.TextView
import com.google.android.material.floatingactionbutton.FloatingActionButton

class GameActivity : AppCompatActivity() {
    companion object {
        var score: Int = 0
    }

    private lateinit var upButton: FloatingActionButton
    private lateinit var downButton: FloatingActionButton
    private lateinit var leftButton: FloatingActionButton
    private lateinit var rightButton: FloatingActionButton

    private var labyrinth = IntArray(0)

    private var playerPosition: Pair<Int, Int> = Pair(0, 0)
    private var dimensions: Pair<Int, Int> = Pair(0, 0)

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_game)
        upButton = findViewById(R.id.upButton)
        downButton = findViewById(R.id.downButton)
        leftButton = findViewById(R.id.leftButton)
        rightButton = findViewById(R.id.rightButton)
        initGame()
    }

    private fun getLabyrinthValue(x: Int, y: Int): Int {
        return labyrinth[x * dimensions.first + y]
    }

    private fun displayCurrentRoomValue() {
        findViewById<TextView>(R.id.valueText).text = getLabyrinthValue(playerPosition.first, playerPosition.second).toString()
    }

    private fun getStartPosition() {
        for (i in 0..labyrinth.size) {
            if (labyrinth[i] and 16 != 0) {
                playerPosition = Pair(i / dimensions.first, i % dimensions.first)
                break
            }
        }
    }

    private fun getLabyrinthDimensions() {
        dimensions = Pair(MainActivity.xDimension, MainActivity.yDimension)
    }

    private fun movePlayer(direction: Int) {
        score++
        when (direction) {
            1 -> playerPosition = Pair(playerPosition.first - 1, playerPosition.second)
            2 -> playerPosition = Pair(playerPosition.first + 1, playerPosition.second)
            3 -> playerPosition = Pair(playerPosition.first, playerPosition.second - 1)
            4 -> playerPosition = Pair(playerPosition.first, playerPosition.second + 1)
        }
        checkIfWin()
        enableDirections(getLabyrinthValue(playerPosition.first, playerPosition.second))
    }

    private fun checkIfWin() {
        if (getLabyrinthValue(playerPosition.first, playerPosition.second) == 0)
            endGame()
    }

    private fun enableDirections(value: Int) {
        downButton.isEnabled = value and 8 == 8
        upButton.isEnabled = value and 4 == 4
        rightButton.isEnabled = value and 2 == 2
        leftButton.isEnabled = value and 1 == 1

    }

    private fun initGame() {
        getLabyrinthDimensions()
        labyrinth = MazeGenerator(dimensions.first, dimensions.second).convertMazeToOneDimensionalArray()
        score = 0
        getStartPosition()
        displayCurrentRoomValue()
        enableDirections(getLabyrinthValue(playerPosition.first, playerPosition.second))

        upButton.setOnClickListener {
            movePlayer(1)
            displayCurrentRoomValue()
        }
        downButton.setOnClickListener {
            movePlayer(2)
            displayCurrentRoomValue()
        }
        leftButton.setOnClickListener {
            movePlayer(3)
            displayCurrentRoomValue()
        }
        rightButton.setOnClickListener {
            movePlayer(4)
            displayCurrentRoomValue()
        }
    }

    private fun endGame() {
        startActivity(Intent(this, EndGameActivity::class.java))
    }
}
