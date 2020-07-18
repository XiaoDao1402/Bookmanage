using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace bookmanage {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            #region ������ע��
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Session ע��
            services.AddSession();
            #endregion

            #region Swagger Api��Ϣע��
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "����ӿ�",
                    Description = "ͼ�����ϵͳ",
                    Contact = new OpenApiContact {
                        Name = "Xiodra",
                        Email = "y.dragon.hu@hotmail.com",
                        Url = new Uri("https://xiodra.github.io"),
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
                    Description = "���¿�����������ͷ����Ҫ���Jwt��ȨToken��Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });

                // ���س��򼯵�xml�����ĵ�
                string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Base.xml");
                c.IncludeXmlComments(basePath);
                string entityPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Entity.xml");
                c.IncludeXmlComments(entityPath);
                var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookManage.xml");
                c.IncludeXmlComments(xmlPath);

                c.EnableAnnotations();
            }
            #endregion

            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ͼ��������ӿ�");
                // ����Swagger��·�ɺ�׺
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            // ������֤
            app.UseAuthentication();
            // ������Ȩ
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}


