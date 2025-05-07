package com.example.demo.models;

import jakarta.persistence.*;
import lombok.*;
import lombok.experimental.FieldDefaults;
import org.hibernate.query.sql.internal.ParameterRecognizerImpl;

import java.io.Serializable;
import java.util.Date;
import java.util.logging.Level;

@Entity
@Setter
@Getter
@AllArgsConstructor
@NoArgsConstructor
@FieldDefaults(level = AccessLevel.PRIVATE)
@ToString
public class Contrat implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int idContrat;

    private String matricule;
    private Date dateEffect;

    @Enumerated(EnumType.STRING)
    private  TypeContrat typec;




}
