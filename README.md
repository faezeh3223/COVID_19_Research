# COVID_19_Research
First, we will describe how to implement the project:
In this project, object-oriented programming method is used, because in order to speed up and conceptualize the project, it is better to look at each article as an object and then index these objects in elasticsearch.
Due to the large size of data in an article, which is the same as .json files, a series of settings must be made on elasticsearch, otherwise this service is not ready to store information in this way.
The first thing we encountered during storage was the limited storage size of fields in elasticsearch. which should be increased by one of the methods mentioned in the educational documents of www.elastic.co according to the used version.
Here we used the method described for the .net version of the API, which is as follows:
client.LowLevel.Indices.UpdateSettingsForAll<StringResponse>(PostData.Serializable(new { index = new { mapping = new { total_fields = new { limit = 100000 } } } }));
Here, the limit value is the size limit of the fields, which is equal to 1000 by default, and we have increased its value to a significant extent.
The next thing to pay attention to is the size of the heap, which also needs to be increased to store long data. Based on the relevant training documents, the jvm.options file should be changed as follows to increase the size of the heap:
![Capture](https://github.com/faezeh3223/COVID_19_Research/assets/50834330/efe201f7-6625-4b76-a20c-1f7e25f021d6)
![image](https://github.com/faezeh3223/COVID_19_Research/assets/50834330/1809d2bf-c7d6-429c-b949-a061c41e8d6e)
![Capture](https://github.com/faezeh3223/COVID_19_Research/assets/50834330/5268e464-bfc6-4251-a3dd-f1a36abfcddf)
Here we have changed the heap size to 4 GB.
After creating the mentioned settings, we can now implement the program and run it:
First, we create the relevant classes based on the .json template given in the json_schema file dataset, which is as follows:
# JSON schema of full text documents


{
    "paper_id": <str>,                      # 40-character sha1 of the PDF
    "metadata": {
        "title": <str>,
        "authors": [                        # list of author dicts, in order
            {
                "first": <str>,
                "middle": <list of str>,
                "last": <str>,
                "suffix": <str>,
                "affiliation": <dict>,
                "email": <str>
            },
            ...
        ],
        "abstract": [                       # list of paragraphs in the abstract
            {
                "text": <str>,
                "cite_spans": [             # list of character indices of inline citations
                                            # e.g. citation "[7]" occurs at positions 151-154 in "text"
                                            #      linked to bibliography entry BIBREF3
                    {
                        "start": 151,
                        "end": 154,
                        "text": "[7]",
                        "ref_id": "BIBREF3"
                    },
                    ...
                ],
                "ref_spans": <list of dicts similar to cite_spans>,     # e.g. inline reference to "Table 1"
                "section": "Abstract"
            },
            ...
        ],
        "body_text": [                      # list of paragraphs in full body
                                            # paragraph dicts look the same as above
            {
                "text": <str>,
                "cite_spans": [],
                "ref_spans": [],
                "eq_spans": [],
                "section": "Introduction"
            },
            ...
            {
                ...,
                "section": "Conclusion"
            }
        ],
        "bib_entries": {
            "BIBREF0": {
                "ref_id": <str>,
                "title": <str>,
                "authors": <list of dict>       # same structure as earlier,
                                                # but without `affiliation` or `email`
                "year": <int>,
                "venue": <str>,
                "volume": <str>,
                "issn": <str>,
                "pages": <str>,
                "other_ids": {
                    "DOI": [
                        <str>
                    ]
                }
            },
            "BIBREF1": {},
            ...
            "BIBREF25": {}
        },
        "ref_entries":
            "FIGREF0": {
                "text": <str>,                  # figure caption text
                "type": "figure"
            },
            ...
            "TABREF13": {
                "text": <str>,                  # table caption text
                "type": "table"
            }
        },
        "back_matter": <list of dict>           # same structure as body_text
    }
}
