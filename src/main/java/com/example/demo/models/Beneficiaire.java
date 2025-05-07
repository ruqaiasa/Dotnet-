package com.example.demo.models;

import jakarta.persistence.*;
import lombok.*;

import java.io.Serializable;
import java.util.List;

@Entity
@Setter
@Getter
@AllArgsConstructor
@NoArgsConstructor
@ToString
public class Beneficiaire implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int idBenf;
    private int cin;
    private String nom;
    private String prenom;
    private String profession;
    private float salaire;

    @OneToMany(mappedBy = "ben")
    private List<Assurance> assurance;


}
