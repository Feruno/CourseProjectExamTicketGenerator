CREATE DEFINER=`root`@`localhost` PROCEDURE `test`(in i varchar(20), 
in quantity_Ticket int, 
in num_exam int,
in s_q_q_t int)
BEGIN

  
drop table if exists NewQuestion;
create table NewQuestion like Question;
insert into NewQuestion select * from Question;


set @num_Ticket = 1;

set @ques_ticket = 1;

set @id_d = (
select id_discipline from discipline where  Name_discipline = i);

delete from Ticket where id_T > 0;

set @q_nq = (select count(id_Question) from NewQuestion);

while (@num_Ticket <= quantity_Ticket) and @q_nq > 0 do


set @maxQ_D =(
  select MAX(id_Question)  from NewQuestion inner join discipline 
  on NewQuestion.code_discipline = discipline.id_discipline 
  where discipline.Name_discipline = i);

set @minQ_D=(
  select MIN(id_Question)   from NewQuestion inner join discipline 
  on NewQuestion.code_discipline = discipline.id_discipline 
  where discipline.Name_discipline = i);
  

  
  set @ques_ticket = 1;
  
  while @ques_ticket <= s_q_q_t do
  
  
  
    set @id_ques_di = ROUND(RAND() * ( @maxQ_D - @minQ_D)) +  @minQ_D;

    update NewQuestion set que_selected = 1 where id_Question = @id_ques_di ;

    insert into Ticket (id_Ticket, id_Question_selected, id_Question, id_discipline, id_exam)
    
    values ( @num_Ticket, @id_ques_di, @ques_ticket, @id_d, num_exam);
    
    select @num_Ticket , @id_ques_di, @ques_ticket, @id_d, num_exam;

delete from NewQuestion where @id_ques_di = id_Question;

set @q_nq = (select count(id_Question) from NewQuestion);
   
    set @ques_ticket = @ques_ticket+1;
    
  end while; 
        set @num_Ticket =@num_Ticket +1;
    
  
end while;


END