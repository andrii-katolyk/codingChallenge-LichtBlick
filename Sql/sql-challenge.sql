-- Solution 1: fetching the most casted together actors in subquery in from statement and joining actors table twice

select
  (a1.first_name || ' ' || a1.last_name) first_actor,
  (a2.first_name || ' ' || a2.last_name) second_actor,
  f.title
from (  
  select 
    fa1.actor_id first_actor,
    fa2.actor_id second_actor
  from film_actor fa1
  join film_actor fa2 on fa1.film_id = fa2.film_id and fa1.actor_id != fa2.actor_id
  group by fa1.actor_id, fa2.actor_id
  order by count(1) desc
  limit 1
) most_casted_together
join actor a1 on a1.actor_id = most_casted_together.first_actor
join actor a2 on a2.actor_id = most_casted_together.second_actor
join film_actor fa1 on fa1.actor_id = a1.actor_id
join film_actor fa2 on fa2.actor_id = a2.actor_id
join film f on f.film_id = fa1.film_id and f.film_id = fa2.film_id;


-- Solution 2: fetching the most casted together actors in a temporary result set using common table expression.


with most_casted_together as (
  select 
    fa1.actor_id first_actor,
    fa2.actor_id second_actor
  from film_actor fa1
  join film_actor fa2 on fa1.film_id = fa2.film_id and fa1.actor_id != fa2.actor_id
  group by fa1.actor_id, fa2.actor_id
  order by count(1) desc
  limit 1
)
  
select
  (select first_name || ' ' || last_name from actor where actor_id = mct.first_actor) first_actor,
  (select first_name || ' ' || last_name from actor where actor_id = mct.second_actor) second_actor,
  f.title
from most_casted_together mct
join film_actor fa1 on fa1.actor_id = mct.first_actor
join film_actor fa2 on fa2.actor_id = mct.second_actor
join film f on f.film_id = fa1.film_id and f.film_id = fa2.film_id;