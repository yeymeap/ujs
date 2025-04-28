Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	; clear bx
	xor bx, bx
	; mov bl, 5

Input:
	; input msg
	mov ah, 9
	mov dx, offset inputmsg
	int 21h
	; input character
	mov ah, 0
	int 16h
	mov bl, al
	; move to correct values
	sub bl, 48

Read:
	; write out message
	mov ah, 9
	mov dx, offset msg
	int 21h
	
	; read input character
	mov ah, 0
	int 16h
	
	; write out input character
	mov ah, 2
	mov dl, al
	int 21h
	
	; compare
	cmp dl, 'a'
	
	; jump if true
	jz True
	
	;jump if false
	jmp False

True:
	; write out message
	mov ah, 9
	mov dx, offset true_msg
	int 21h
	
	; end
	jmp Program_Vege

False:
	; write out message
	mov ah, 9
	mov dx, offset false_msg
	int 21h
	dec bl
	mov ah, 2
	mov dl, bl
	add dl, 48
	int 21h
	
	; compare bl
	cmp bl, 0
	; if true end 
	jz EndMsg
	; else jump back to read
	jmp Read

EndMsg:
	mov ah, 9
	mov dx, offset end_msg
	int 21h
	
Program_Vege:
	mov	ax, 4c00h
	int	21h

inputmsg: db "Add meg a lehetosegek szamat:$"
msg: db 10, "Irj be egy 'a' betut: $"
true_msg: db 10, "Program vege$"
false_msg: db 10, "Nem a megfelelo karakter, probald ujra! Lehetosegek szama: $"
end_msg: db 10, "Elfogytak a lehetosegek!$"
Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

