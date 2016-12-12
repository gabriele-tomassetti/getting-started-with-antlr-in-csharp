grammar Speak;

/*
 * Parser Rules
 */

chat				: line line EOF ;

line				: name SAYS word NEWLINE;

name				: WORD ;

word				: WORD ;

/*
 * Lexer Rules
 */

fragment A			: ('A'|'a') ;
fragment S			: ('S'|'s') ;
fragment Y          : ('Y'|'y') ;

fragment LOWERCASE  : [a-z] ;
fragment UPPERCASE  : [A-Z] ;

SAYS				: S A Y S ;

WORD				: (LOWERCASE | UPPERCASE)+ ;

WHITESPACE			: (' '|'\t')+ -> skip ;

NEWLINE				: ('\r'? '\n' | '\r')+ ;
