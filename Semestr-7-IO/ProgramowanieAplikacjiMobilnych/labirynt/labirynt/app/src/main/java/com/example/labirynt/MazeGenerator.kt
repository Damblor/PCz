package com.example.labirynt

import java.util.Random

class MazeGenerator(private val width: Int, private val height: Int) {
    private val maze: Array<IntArray> = Array(height) { IntArray(width) }
    private val directions = arrayOf(
        Pair(0, -1), // left
        Pair(0, 1), // right
        Pair(-1, 0), // up
        Pair(1, 0) // down
    )
    private val random = Random()

    init {
        generateMaze()
    }

    private fun generateMaze() {
        for (row in maze.indices) {
            for (col in maze[row].indices) {
                maze[row][col] = 0
            }
        }
        val startRow = random.nextInt(height)
        val startCol = random.nextInt(width)
        maze[startRow][startCol] = 16
        createMaze(startRow, startCol)
        var endRow = random.nextInt(height)
        var endCol = random.nextInt(width)
        while (endRow == startRow && endCol == startCol) {
            endRow = random.nextInt(height)
            endCol = random.nextInt(width)
        }
        maze[endRow][endCol] = 0
    }

    private fun createMaze(row: Int, col: Int) {
        val directionsList = directions.toMutableList()
        directionsList.shuffle()
        for ((dx, dy) in directionsList) {
            val newRow = row + dx
            val newCol = col + dy
            if (isValid(newRow, newCol)) {
                if (maze[newRow][newCol] == 0) {
                    maze[row][col] = maze[row][col] or getDirection(dx, dy)
                    maze[newRow][newCol] = maze[newRow][newCol] or getOppositeDirection(dx, dy)
                    createMaze(newRow, newCol)
                }
            }
        }
    }

    private fun isValid(row: Int, col: Int): Boolean {
        return row in 0 until height && col in 0 until width
    }

    private fun getDirection(dx: Int, dy: Int): Int {
        return when {
            dx == 0 && dy == -1 -> 1 // left
            dx == 0 && dy == 1 -> 2 // right
            dx == -1 && dy == 0 -> 4 // up
            dx == 1 && dy == 0 -> 8 // down
            else -> 0
        }
    }

    private fun getOppositeDirection(dx: Int, dy: Int): Int {
        return when {
            dx == 0 && dy == -1 -> 2 // left opposite
            dx == 0 && dy == 1 -> 1 // right opposite
            dx == -1 && dy == 0 -> 8 // up opposite
            dx == 1 && dy == 0 -> 4 // down opposite
            else -> 0
        }
    }

    fun convertMazeToOneDimensionalArray(): IntArray {
        val mazeOneDimensional = IntArray(width * height)
        for (row in maze.indices) {
            for (col in maze[row].indices) {
                mazeOneDimensional[row * width + col] = maze[row][col]
            }
        }
        return mazeOneDimensional
    }
}
