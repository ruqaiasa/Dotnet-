package com.example.demo.repo;

import com.example.demo.models.Assurance;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface IAssuranceRepo extends JpaRepository<Assurance,Integer> {
}
