
# LearningAutoMapper

Simple program to understand the difference between these two cases: 

1. destination = AutoMapper.Map<T1, T2>(source);
2. AutoMapper.Map<T1, T2>(source, destination);


- - - 

### Flow for *[ dest = mapper.Map<Source, Dest>(source); ]*  
  
**Dest d = new Dest(); < - - - the main difference !**  
d1.MyProperty1 = source.MyProperty1  
d1.MyProperty2 = source.MyProperty2  

### Flow for *[ mapper.Map<Source, Destination>(source, dest); ]*

destination.MyProperty1 = source.MyProperty1  
destination.MyProperty2 = source.MyProperty2  
          
