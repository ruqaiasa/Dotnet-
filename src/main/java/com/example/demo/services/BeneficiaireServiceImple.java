package com.example.demo.services;

import com.example.demo.models.Beneficiaire;
import com.example.demo.repo.IAssuranceRepo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class BeneficiaireServiceImple implements IBeneficiaireService {
    @Autowired
    private  IAssuranceRepo repo;


    @Override
    public Beneficiaire ajouterBen(Beneficiaire bf) {
        return repo.save(bf);
    }
}
