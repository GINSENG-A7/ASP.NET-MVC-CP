﻿SELECT a.id FROM Apartments a WHERE a.price > 0 AND a.price < 999999 AND ((a.id IN (SELECT apartmentsid FROM Livings WHERE eviction < '2021-05-25') AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE a.id IN (SELECT apartmentsid FROM Bookings))) OR (a.id in (SELECT apartmentsid FROM Bookings WHERE settling > '2021-05-26') OR (a.id in (SELECT apartmentsid FROM Bookings WHERE eviction < '2021-05-25'))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE a.id IN (SELECT apartmentsid FROM Livings)) OR ((a.id in (SELECT apartmentsid FROM Livings WHERE eviction<'2021-05-25')) AND (a.id in (SELECT apartmentsid FROM Bookings WHERE settling>'2021-05-26') OR (a.id in (SELECT apartmentsid FROM Bookings WHERE eviction<'2021-05-25')))) OR (a.id NOT IN (SELECT apartmentsid FROM Livings) AND a.id NOT IN (SELECT apartmentsid FROM Bookings)))
SELECT * FROM Apartments b WHERE b.Id IN (SELECT a.id FROM Apartments a WHERE a.price > 0 AND a.price < 999999 AND ((a.id IN (SELECT apartmentsid FROM Livings WHERE eviction < '2021-05-25') AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE a.id IN (SELECT apartmentsid FROM Bookings))) OR (a.id in (SELECT apartmentsid FROM Bookings WHERE settling > '2021-05-26') OR (a.id in (SELECT apartmentsid FROM Bookings WHERE eviction < '2021-05-25'))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE a.id IN (SELECT apartmentsid FROM Livings)) OR ((a.id in (SELECT apartmentsid FROM Livings WHERE eviction<'2021-05-25')) AND (a.id in (SELECT apartmentsid FROM Bookings WHERE settling>'2021-05-26') OR (a.id in (SELECT apartmentsid FROM Bookings WHERE eviction<'2021-05-25')))) OR (a.id NOT IN (SELECT apartmentsid FROM Livings) AND a.id NOT IN (SELECT apartmentsid FROM Bookings))))
SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > 0 AND a.price < 999999 AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '2021-05-25' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '2021-05-26' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '2021-05-25' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'2021-05-25' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'2021-05-26' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'2021-05-25' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))
SELECT * FROM Apartments b INNER JOIN ta."type" ApartmentTypes ta ON b.apartmenttypeid = ta.id WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > 0 AND a.price < 999999 AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '2021-05-25' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '2021-05-26' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '2021-05-25' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'2021-05-25' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'2021-05-26' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'2021-05-25' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))