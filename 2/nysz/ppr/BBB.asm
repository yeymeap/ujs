;név: 
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX
	
	


	; 1. FELADAT
	; írasson ki * karakterek segítségével egy derékszögű háromszöget, ahol minden * egy külön karakter a köv. formában:
	; *    -> hexadecimális
	; **   -> decimális
	; ***  -> idézőjeles
	; 2 pont ha mind a 3 sor más típusú (hexa, dec, idéző) ascii karakterekből épül fel
	; 1 pont ha mind a 3 sor egy típusú ascii karakterből épül fel
	
	mov ah, 2
	mov dl, 2ah
	int 21h
	
	mov dl, 10
	int 21h
	
	mov dl, 42
	int 21h
	int 21h
	
	mov dl, 10
	int 21h
	mov dl, '*'
	int 21h
	int 21h
	int 21h
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

	; 2. FELADAT
	; Kérje be a téglalap oldalainak hosszát, majd számítsa ki annak területét T = a * b
	; A feladathoz hasznalja a szam1, szam2, eredmeny, cm2 üzeneteket (alul elérhetőek)
	; 2 pont ha kétjegyű számok is kijöhetnek eredményül
	; 1 pont ha csak egyjegyű számok jöhetnek ki eredményül
Rectangle:
	
	mov ah, 9
	mov dx, offset szam1
	int 21h
	
	mov ah, 0
	int 16h
	
	mov ah, 2
	mov dl, al
	int 21h
	
	cmp al, '0'
	jl Rectangle
	cmp al, '9'
	jg Rectangle
	
	mov bl, al
	
	mov ah, 9
	mov dx, offset szam2
	int 21h
	
	mov ah, 0
	int 16h
	
	cmp al, '0'
	jl Rectangle
	cmp al, '9'
	jg Rectangle
	
	mov ah, 2
	mov dl, al
	int 21h
	
	mov bh, al
	sub bl, 48
	sub bh, 48
	
	mov al, bh
	
	mul bl
	
	mov cx, 10
	
	div cl
	
	mov bl, al
	mov bh, ah
	
	add bl, 48
	add bh, 48
	
	mov ah, 9
	mov dx, offset eredmeny
	int 21h
	
	mov ah, 2
	mov dl, bl
	int 21h
	
	mov dl, bh
	int 21h


;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

	; 3. FELADAT
	; Ciklus segítségével írasson ki 2 sorba 10db = jelet
	; 2 pont ha ket sornyi ========== jel iratodik ki
	; 1 pont ha csak egy sornyi ========== jel iratodik ki
	
Starting_bx:
	
	mov ah, 2
	mov dl, 10
	int 21h
	
	xor bx, bx
	mov bl, 0
	mov bh, 0
	
Looper:

	mov ah, 2
	mov dl, '='
	int 21h
	cmp bl, 9
	jz Newline
	inc bl
	jmp Looper

Newline:
	inc bh
	mov ah, 2
	mov dl, 10
	int 21h
	cmp bh, 2
	jz text
	mov bl, 0
	jmp Looper

	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

	; 4. FELADAT
	; Irjon feladatot, amely akkor engedi kilepni a programbol a felhasznalot:
	; ha "x" vagy "X" karaktert olvastat be
	; 2 pont ha mind a 2 karaktert (kis és nagy) képes kezelni
	; 1 pont ha csak az egyik karaktert kezeli
Text:
	mov ah, 9
	mov dx, offset kilepes
	int 21h
	
Inputs:
	mov ah, 0
	int 16h
	
	mov ah, 2
	mov dl, al
	int 21h
	
	cmp dl, 'x'
	jz Program_Vege
	cmp dl, 'X'
	jz Program_Vege
	jmp Inputs

	
Program_Vege:
	mov	ax, 4c00h
	int	21h

szam1: db 10, "A oldal: $"
szam2: db 10, "B oldal: $"
eredmeny: db 10, "Terulet: $"
cm2: db "cm2$"
kilepes: db 10, "Kilepeshez x vagy X: $"


Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

