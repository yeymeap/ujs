Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
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
	
	jmp Read
	
Program_Vege:
	mov	ax, 4c00h
	int	21h

msg: db 10, "Irj be egy 'a' betut: $"
true_msg: db 10, "Program vege$"
false_msg: db 10, "Nem a megfelelo karakter, probald ujra!$"
Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

