Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	; write out start msg
	mov ah, 9
	mov dx, offset start_msg
	int 21h
	
Input_char:
	; write out input msg
	;mov ah, 9
	mov dx, offset input_msg
	int 21h
	
	; input character
	mov ah, 0
	int 16h
	
	; write out input character as feedback
	mov ah, 2
	mov dl, al
	int 21h
	
	; save input character
	mov bl, al
	
Input_row:
	; write out row message
	mov ah, 9
	mov dx, offset row_msg
	int 21h
	
	; input character
	mov ah, 0
	int 16h
	
	; write out input character as feedback
	mov ah, 2
	mov dl, al
	int 21h
	
	; check if input is number
	cmp al, '0'
	jl Input_row
	cmp al, '9'
	jg Input_row
	
	; save row number, move to range
	mov cl, al
	sub cl, 48
	
Input_col:
	; write out col message
	mov ah, 9
	mov dx, offset col_msg
	int 21h
	
	; input character
	mov ah, 0
	int 16h
	
	; write out input character as feedback
	mov ah, 2
	mov dl, al
	int 21h
	
	; check if input is number
	cmp al, '0'
	jl Input_col
	cmp al, '9'
	jg Input_col
	
	; save col number, move to range
	mov ch, al
	sub ch, 48
		
Output:
	; write output msg
	mov ah, 9
	mov dx, offset output_msg
	int 21h
	
	; newline
	mov ah, 2
	mov dl, 10
	int 21h
	
	; move character to dh
	mov dh, bl
	
	; zero bx
	xor bx, bx
	
ForLoop:
	; pre increment
	inc bh
	
	; write out character
	mov ah, 2
	mov dl, dh
	int 21h
	
	; space
	mov dl, 32
	int 21h
	
	; compare
	cmp bh, ch
	jz Newline
	jmp ForLoop

Newline:
	; pre increment
	inc bl
	
	; newline
	mov ah, 2
	mov dl, 10
	int 21h
	
	; compare
	cmp bl, cl
	jz Check_restart
	mov bh, 0 ; reset col counter
	jmp ForLoop
	
Check_restart:
	; write out restart message
	mov ah, 9
	mov dx, offset check_msg
	int 21h
	
	; input character
	mov ah, 0
	int 16h
	
	; write out input character as feedback
	mov ah, 2
	mov dl, al
	int 21h
	
	; evaluate condition
	cmp al, 'i'
	jnz Not_i
	jmp Start
	
Not_i:
	; evaluate condition
	cmp al, 'n'
	jnz Check_restart
	jmp Program_Vege
	
Program_Vege:
	mov	ax, 4c00h
	int	21h

start_msg: db 10, "Karakter kiiro program sor es oszlopban$"
input_msg: db 10, "Adjon meg egy karaktert: $"
row_msg: db 10, "Hany sorban szeretne a karaktert megjeleniteni: $"
col_msg: db 10, "Hany oszlopban szeretne a karaktert megjeleniteni: $"
check_msg: db 10, "Szeretne ujrainditani a programot? (i/n): $"
output_msg: db 10, "Karakterek megjelenitese: $"

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

