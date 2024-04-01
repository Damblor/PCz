import random
def print_board(board):
    for row in board:
        print(" | ".join(row))
    print("-" * 9)

def check_winner(board, player):
    for row in board:
        if all(cell == player for cell in row):
            return True
    for col in range(3):
        if all(board[row][col] == player for row in range(3)):
            return True
    if all(board[i][i] == player for i in range(3)) or all(board[i][2 -
    i] == player for i in range(3)):
        return True
    return False

def is_board_full(board):
    return all(cell != ' ' for row in board for cell in row)

def get_bot_move(board):
    available_moves = [(row, col) for row in range(3) for col in range(3)
    if board[row][col] == ' ']
    return random.choice(available_moves)

def main():
    board = [[' ' for _ in range(3)] for _ in range(3)]
    current_player = 'X'
    print("Witaj w grze w kółko i krzyżyk!")
    while True:
        print_board(board)
        if current_player == 'X':
            row = int(input(f"Gracz {current_player}, wybierz wiersz (0, 1, 2): "))
            col = int(input(f"Gracz {current_player}, wybierz kolumnę (0, 1, 2): "))
        else:
            print(f"Bot ({current_player}) wybiera ruch...")
            row, col = get_bot_move(board)
        if board[row][col] == ' ':
            board[row][col] = current_player
            if check_winner(board, current_player):
                print_board(board)
                print(f"Gracz {current_player} wygrywa!")
                break
            elif is_board_full(board):
                print_board(board)
                print("Remis!")
                break
            current_player = 'O' if current_player == 'X' else 'X'
        else:
            print("To pole jest już zajęte. Wybierz inne.")

if __name__ == "__main__":
    main()